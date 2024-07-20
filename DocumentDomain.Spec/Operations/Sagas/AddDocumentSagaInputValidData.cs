namespace DocumentDomain.Spec.Operations.Sagas;

using System.Collections;
using Contracts;

public class AddDocumentSagaInputValidData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new DocumentInput { Id = 0, Name = "asd", Description = "asd" }
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}