//create a WinRAR clone
//WINRARA can compress and decompress ZIP and RAR files

List<string> files = new()
{
    "introduction.doc",
    "Readme.md",
    "test.txt"
};

Compressor zip = new ZipCompressor();
Compressor rar = new RarCompressor();
zip.Compress(files);
zip.Extract("ttttt");

rar.Compress(files);
rar.Extract("yyyyy");

public abstract class Compressor
{
    public CompressionStrategy CompressionStrategy { get; set; }
    public ExtractionStrategy ExtractionStrategy { get; set;
    }
    public void Compress(List<string> filenames)
    {
        CompressionStrategy.Compress(filenames);
    }
    public void Extract(string filename)
    {
        ExtractionStrategy.Extract(filename);
    }
}

public class ZipCompressor : Compressor
{
    public ZipCompressor()
    {
        CompressionStrategy = new CompressToZip();
        ExtractionStrategy = new ExtractionRecoveryFile();
    }
}

public class RarCompressor : Compressor
{
    public RarCompressor()
    {
        CompressionStrategy = new CompressLossy();
        ExtractionStrategy = new ExtractionRecoveryWithoutFile();
    }
}
//strategies
public interface CompressionStrategy
{
    public void Compress(List<string> fileNames);
}

public class CompressToRAR : CompressionStrategy
{
    public void Compress(List<string> fileNames)
    {
        foreach ( string name in fileNames )
        {
            Console.WriteLine($"Adding {name} to RAR file...");
        }
        Console.WriteLine("Compressed to rar file");
    }
}

public class CompressToZip : CompressionStrategy
{
    public void Compress(List<string> fileNames)
    {
        foreach ( string name in fileNames )
        {
            Console.WriteLine($"Adding {name} to Zip file...");
        }
        Console.WriteLine("Compressed to zip file");
    }
}
public class CompressLossLess: CompressionStrategy
{
    public void Compress(List<string> fileNames)
    {
        fileNames.ForEach(f =>
        {
            Console.WriteLine($"Compressing {f} in lossless format");
        });
    }    
}
public class CompressLossy : CompressionStrategy
{
    public void Compress(List<string> fileNames)
    {
        fileNames.ForEach(f =>
        {
            Console.WriteLine($"Compressing {f} in lossy format");
        });
    }
}

//extraction strategies
public interface ExtractionStrategy
{
    public void Extract(string fileName);
}

public class ExtractionRecoveryFile : ExtractionStrategy
{
    public void Extract(string fileName)
    {
        Console.WriteLine($"Excracting from {fileName} with file");
    }
}

public class ExtractionRecoveryWithoutFile : ExtractionStrategy
{
    public void Extract(string fileName)
    {
        Console.WriteLine($"Excracting from {fileName} without file ");
    }
}