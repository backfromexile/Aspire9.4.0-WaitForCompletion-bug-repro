namespace IRunBeforeAnythingElse;

public class Program
{
    public static async Task Main(string[] args)
    {
        await Task.Delay(5_000); // simulate some kind of delay

        var shouldThrow = Environment.GetEnvironmentVariable("I_SHOULD_THROW")?.ToUpper() == "TRUE";
        if (shouldThrow)
        {
            Environment.Exit(-1);
        }
    }
}
