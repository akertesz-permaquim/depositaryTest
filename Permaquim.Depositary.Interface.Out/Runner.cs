// See https://aka.ms/new-console-template for more information
public class Runner
{
    public string Path { get; set; }
    private IOutputInterface _outputInterface;
    public Runner(string path,string interFace)
    {
        Path = path;
        string fqdn = GetFullyQualifiedTypeName(interFace);
        if (!(fqdn == null || fqdn.Equals(string.Empty)))
        {
            _outputInterface = (IOutputInterface) GetInstance(fqdn, Path);
        }
    }

    public void ProcessInterface()
    {
        _outputInterface.Process();
    }

    private static string GetFullyQualifiedTypeName(string shortTypeName)
    {
        //GET fullyQualifiedDomainName
        return AppDomain.CurrentDomain.GetAssemblies()
            .ToList()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.Name == shortTypeName)
            .Select(x => x.FullName)
            .FirstOrDefault();
    }
    public object GetInstance(string strFullyQualifiedName, string outPath)
    {
        Type type = Type.GetType(strFullyQualifiedName);
        if (type != null)
            return Activator.CreateInstance(type, outPath);
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            type = asm.GetType(strFullyQualifiedName);
            if (type != null)
                return Activator.CreateInstance(type, outPath);
        }
        return null;
    }
}