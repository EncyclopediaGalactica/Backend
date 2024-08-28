namespace DocumentDomain.Spec.Operations.Scenario;

using DocumentDomain.Operations.Commands;
using DocumentDomain.Operations.Commands.Application;
using DocumentDomain.Operations.Commands.DocumentType;
using DocumentDomain.Operations.Scenarios;
using DocumentDomain.Operations.Scenarios.Application;
using DocumentDomain.Operations.Scenarios.DocumentType;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentValidation;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Infrastructure.Validators;
using Infrastructure.Validators.Application;
using LanguageExt;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class ScenarioBaseTest : IDisposable
{
    private readonly IValidator<DocumentInput> _addDocumentSagaInputValidator;
    private readonly IDocumentInputMapper _documentInputMapper;
    private readonly IDocumentMapper _documentMapper;
    private readonly DocumentStructureNodeInputValidator _documentStructureNodeInputValidator;
    private readonly IDocumentStructureNodeMapper _documentStructureNodeMapper;
    protected readonly AddDocumentSaga AddDocumentSaga;
    protected readonly AddDocumentTypeScenario AddDocumentTypeScenario;
    protected readonly DeleteDocumentTypeScenario DeleteDocumentTypeScenario;
    protected readonly UpdateDocumentTypeScenario UpdateDocumentTypeScenario;
    private IAddApplicationCommand _addApplicationCommand;
    private IAddDocumentCommand _addDocumentCommand;
    private AddDocumentTypeCommand _addDocumentTypeCommand;
    private IAddStructureNodeTreeCommand _addStructureNodeTreeCommand;
    private ApplicationMapper _applicationMapper;
    private SqliteConnection _connection;
    private DbContextOptions<DocumentDomainDbContext> _dbContextOptions;
    private IDeleteDocumentTypeCommand _deleteDocumentTypeCommand;
    private IDocumentTypeMapper _documentTypeMapper;
    private IGetDocumentByIdCommand _getDocumentByIdCommand;
    private GetDocumentTypeByIdCommand _getDocumentTypeByIdCommand;
    private IUpdateDocumentTypeCommand _updateDocumentTypeCommand;
    protected AddApplicationScenario AddApplicationScenario;
    protected DeleteApplicationScenario DeleteApplicationScenario;
    protected GetApplicationsScenario GetApplicationsScenario;
    protected GetDocumentTypeByIdScenario GetDocumentTypeByIdScenario;
    protected GetDocumentTypesScenario GetDocumentTypesScenario;
    protected UpdateApplicationScenario UpdateApplicationScenario;

    protected ScenarioBaseTest()
    {
        InitializeDbContext();
        _documentMapper = new DocumentMapper();
        _documentInputMapper = new DocumentInputMapper();
        _addDocumentSagaInputValidator = new AddDocumentScenarioInputValidator();
        InitializeAddDocumentCommand();

        _documentStructureNodeMapper = new DocumentStructureNodeMapper();
        _documentStructureNodeInputValidator = new DocumentStructureNodeInputValidator();
        InitialzeAddStructureNodeTreeCommand();

        InitializeGetDocumentByIdCommand();
        AddDocumentSaga = new AddDocumentSaga(
            _addDocumentCommand!,
            _addStructureNodeTreeCommand!,
            _getDocumentByIdCommand!,
            InitializeLogging<AddDocumentSaga>()
        );

        InitializeAddDocumentTypeCommand();
        AddDocumentTypeScenario = new AddDocumentTypeScenario(
            _addDocumentTypeCommand!);

        InitializeUpdateDocumentTypeCommand();
        UpdateDocumentTypeScenario = new UpdateDocumentTypeScenario(_updateDocumentTypeCommand!);

        InitializeDeleteDocumentTypeCommand();
        DeleteDocumentTypeScenario = new DeleteDocumentTypeScenario(_deleteDocumentTypeCommand!);

        InitalizeGetDocumentTypesScenario();
        InitializeGetDocumentTypeByIdScenario();

        InitializeAddApplicationScenario();
        InitializeDeleteApplicationScenario();
        InitializeUpgradeApplicationScenario();
        InitializeGetApplicationsScenario();
    }


    public void Dispose() => _connection.Dispose();

    private void InitializeGetApplicationsScenario()
    {
        GetApplicationsCommand getApplicationsCommand = new GetApplicationsCommand(_applicationMapper, _dbContextOptions);
        GetApplicationsScenario = new GetApplicationsScenario(getApplicationsCommand);
    }

    private void InitializeUpgradeApplicationScenario()
    {
        UpdateApplicationScenarioInputValidator validator = new UpdateApplicationScenarioInputValidator();
        UpdateApplicationCommand updateApplicationCommand = new UpdateApplicationCommand(
            _applicationMapper,
            validator,
            _dbContextOptions);
        UpdateApplicationScenario = new UpdateApplicationScenario(updateApplicationCommand);
    }

    private void InitializeDeleteApplicationScenario()
    {
        DeleteApplicationCommand deleteApplicationCommand = new DeleteApplicationCommand(
            new DeleteApplicationScenarioInputValidator(), _dbContextOptions);
        DeleteApplicationScenario = new DeleteApplicationScenario(deleteApplicationCommand);
    }

    private void InitializeAddApplicationScenario()
    {
        _applicationMapper = new ApplicationMapper();
        _addApplicationCommand = new AddApplicationCommand(
            _applicationMapper,
            new AddApplicationScenarioInputValidator(),
            _dbContextOptions,
            InitializeLogging<AddApplicationCommand>()
        );
        AddApplicationScenario = new AddApplicationScenario(_addApplicationCommand);
    }

    private void InitializeGetDocumentTypeByIdScenario()
    {
        _documentTypeMapper = new DocumentTypeMapper();
        _getDocumentTypeByIdCommand = new GetDocumentTypeByIdCommand(
            _documentTypeMapper,
            _dbContextOptions
        );
        GetDocumentTypeByIdScenario = new GetDocumentTypeByIdScenario(_getDocumentTypeByIdCommand);
    }

    private void InitalizeGetDocumentTypesScenario()
    {
        GetDocumentTypesCommand getDocumentTypesCommand = new GetDocumentTypesCommand(
            new DocumentTypeMapper(),
            _dbContextOptions);
        GetDocumentTypesScenario = new GetDocumentTypesScenario(getDocumentTypesCommand);
    }

    private void InitializeDeleteDocumentTypeCommand()
    {
        _deleteDocumentTypeCommand = new DeleteDocumentTypeCommand(
            new DocumentTypeMapper(),
            new DeleteDocumentTypeScenarioInputValidator(),
            _dbContextOptions);
    }

    private void InitializeUpdateDocumentTypeCommand()
    {
        _updateDocumentTypeCommand = new UpdateDocumentTypeCommand(
            new UpdateDocumentTypeScenarioInputValidator(),
            new DocumentTypeMapper(),
            _dbContextOptions);
    }

    private void InitializeAddDocumentTypeCommand()
    {
        _addDocumentTypeCommand = new AddDocumentTypeCommand(
            new AddDocumentTypeScenarioInputValidator(),
            new DocumentTypeMapper(),
            _dbContextOptions);
    }

    private void InitializeGetDocumentByIdCommand()
    {
        _getDocumentByIdCommand = new GetDocumentByIdCommand(
            _documentMapper,
            _dbContextOptions,
            InitializeLogging<GetDocumentByIdCommand>());
    }

    private void InitialzeAddStructureNodeTreeCommand()
    {
        _addStructureNodeTreeCommand = new AddStructureNodeTreeCommand(
            _documentStructureNodeMapper,
            _dbContextOptions,
            _documentStructureNodeInputValidator,
            InitializeLogging<AddStructureNodeTreeCommand>()
        );
    }

    private void InitializeAddDocumentCommand()
    {
        _addDocumentCommand = new AddDocumentCommand(
            _documentMapper,
            _documentInputMapper,
            _addDocumentSagaInputValidator,
            _dbContextOptions,
            InitializeLogging<AddDocumentCommand>()
        );
    }

    private ILogger<T> InitializeLogging<T>()
    {
        return LoggerFactory.Create(builder => { builder.AddConsole(); }).CreateLogger<T>();
    }

    private void InitializeDbContext()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        _dbContextOptions = new DbContextOptionsBuilder<DocumentDomainDbContext>()
            .UseSqlite(_connection)
            .LogTo(Console.WriteLine)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .Options;

        using DocumentDomainDbContext context = new DocumentDomainDbContext(_dbContextOptions);
        context.Database.EnsureCreated();
    }

    protected async Task SeedAndForgetApplications(int v)
    {
        for (int i = 0; i < v; i++)
        {
            await AddApplicationScenario.ExecuteAsync(new AddApplicationScenarioContext
            {
                CorrelationId = Guid.NewGuid(),
                Payload = new ApplicationInput
                {
                    Id = 0,
                    Name = $"seeded name {i}",
                    Description = $"seeded description {i}"
                }
            });
        }
    }

    protected async Task<Dictionary<long, ApplicationResult>> SeedApplications(int v)
    {
        Dictionary<long, ApplicationResult> result = new();
        for (int i = 0; i < v; i++)
        {
            Option<ApplicationResult> r = await AddApplicationScenario.ExecuteAsync(new AddApplicationScenarioContext
            {
                CorrelationId = Guid.NewGuid(),
                Payload = new ApplicationInput
                {
                    Id = 0,
                    Name = $"seeded name {i}",
                    Description = $"seeded description {i}"
                }
            });
            r.IfSome(item => { result.Add(item.Id, item); });
        }

        return result;
    }
}