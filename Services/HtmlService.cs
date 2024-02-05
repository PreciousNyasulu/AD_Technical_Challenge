namespace NaLib.Services;
public class HtmlService
{
    public string ServeFile(string FileName)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Pages", FileName);       
        return File.ReadAllText(filePath);
    }

    public bool FileExists(string FileName)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Pages", FileName);
        return File.Exists(filePath);
    }
}