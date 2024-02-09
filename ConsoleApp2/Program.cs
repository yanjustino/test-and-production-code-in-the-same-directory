// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


record Command(string Name, long ExternalId);

public partial class Program
{
    private static object? GetByNameFromDb(string name) => new { };
    private static object? GetByIdFromDb(object id) => new { };
    private static (bool arlreadyExists, int id) SaveOnDbWithIdempotency(object entity) => (true, 0);

    
    private static object? FluxoIdempotenteNaBase(Command command)
    {
        var entityInDb = GetByNameFromDb(command.Name);
        if (entityInDb is not null)
            return entityInDb;

        // SaveOnDbWithIdempotency = Trata exceção de constraint na base
        (bool arlreadyExists, int id) = SaveOnDbWithIdempotency(new { });
        return arlreadyExists ? GetByNameFromDb(command.Name) : GetByIdFromDb(id);
    }
}




