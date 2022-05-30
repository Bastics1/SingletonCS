using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Базовый абстрактный класс Document
public abstract class Document
{
    public string DocumentName { get; set; }
    public string DocumentAutor { get; set; }
    public string DocumentKeyWords { get; set; }
    public string DocumentFilePath { get; set; }

    protected Document() { }

    protected Document(string Name, string Autor, string KeyWords, string FilePath)
    {
        DocumentName = Name;
        DocumentAutor = Autor;
        DocumentKeyWords = KeyWords;
        DocumentFilePath = FilePath;
    }
    public abstract void Info();
}

public class MSWordDocument : Document
{
    public int DocumentWordCount { get; set; }
    public MSWordDocument(string Name, string Autor, string KeyWords, string FilePath,int WordCount)
    : base(Name, Autor, KeyWords, FilePath)
    {
        DocumentWordCount = WordCount;
    }
    //Переопределение информации о документе
    public override void Info()
    {
        Console.WriteLine("MSWord Document");
        Console.WriteLine($"Document Name: {DocumentName} \n" +
                          $"Document Autor: {DocumentAutor} \n" +
                          $"Document Key Words: {DocumentKeyWords} \n" +
                          $"Document File Path: {DocumentFilePath} \n" +
                          $"Document Word Count: {DocumentWordCount} ");
    }
}

public class PDFDocument : Document
{
    public int DocumentPageCount { get; set; }
    public PDFDocument(string Name, string Autor, string KeyWords, string FilePath, int PageCount)
    : base(Name, Autor, KeyWords, FilePath)
    {
        DocumentPageCount = PageCount;

    }
    public override void Info()
    {
        Console.WriteLine("PDF Document");
        Console.WriteLine($"Document Name: {DocumentName} \n" +
                          $"Document Autor: {DocumentAutor} \n" +
                          $"Document Key Words: {DocumentKeyWords} \n" +
                          $"Document File Path: {DocumentFilePath} \n" +
                          $"Document Page Count: {DocumentPageCount}");
    }
}

public class MSExcelDocument : Document
{
    public int DocumentCellCount { get; set; }
    public MSExcelDocument(string Name, string Autor, string KeyWords, string FilePath, int CellCount)
    : base(Name, Autor, KeyWords, FilePath)
    {
        DocumentCellCount = CellCount;
    }
    public override void Info()
    {
        Console.WriteLine("MSExcel Document");
        Console.WriteLine($"Document Name: {DocumentName} \n " +
                          $"Document Autor: {DocumentAutor} \n" +
                          $"Document Key Words: {DocumentKeyWords} \n" +
                          $"Document File Path: {DocumentFilePath} \n" +
                          $"Document Cell Count: {DocumentCellCount}");
    }
}

public class TXTDocument : Document
{
    public int DocumentLetterCount { get; set; }
    public TXTDocument(string Name, string Autor, string KeyWords, string FilePath, int LetterCount)
    : base(Name, Autor, KeyWords, FilePath)
    {
        DocumentLetterCount = LetterCount;
    }
    public override void Info()
    {
        Console.WriteLine("TXT Document");
        Console.WriteLine($"Document Name: {DocumentName} \n " +
                          $"Document Autor: {DocumentAutor} \n" +
                          $"Document Key Words: {DocumentKeyWords} \n" +
                          $"Document File Path: {DocumentFilePath} \n" +
                          $"Document Letter Count: {DocumentLetterCount}");
    }
}

public class HTMLDocument : Document
{
    public int DocumentStrokeCount { get; set; }
    public HTMLDocument(string Name, string Autor, string KeyWords, string FilePath, int StrokeCount)
    : base(Name, Autor, KeyWords, FilePath)
    {
        DocumentStrokeCount = StrokeCount;
    }
    public override void Info()
    {
        Console.WriteLine("HTML Document");
        Console.WriteLine($"Document Name: {DocumentName} \n " +
                          $"Document Autor: {DocumentAutor} \n" +
                          $"Document Key Words: {DocumentKeyWords} \n" +
                          $"Document File Path: {DocumentFilePath} \n" +
                          $"Document Cell Count: {DocumentStrokeCount}");
    }
}

namespace SingletonCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.Instance.Start(); 
        }
    }
}

public class Menu
{
    public void Start()
    {
        while (true)
        {
            Console.WriteLine
                (
                $"\nВыберите документ: \n " +
                $"1 - MSWord \n " +
                $"2 - PDF \n " +
                $"3 - Excel \n " +
                $"4 - Txt \n  " +
                $"5 - Html \n" +
                $"6 - Выйти \n"
                );

            int Number = Convert.ToInt32(Console.ReadLine());
            if (Number == 6)
            {
                break;
            }
            switch (Number)
            {
                case 1:
                    Menu.Instance.MSWord();
                    break;
                case 2:
                    Menu.Instance.PDF();
                    break;
                case 3:
                    Menu.Instance.Excel();
                    break;
                case 4:
                    Menu.Instance.Txt();
                    break;
                case 5:
                    Menu.Instance.Html();
                    break;
            }
        }
    }
    //Singleton
    public static Menu Instance                                          
    {
        get
        {
            if (instance == null) {
                instance = new Menu();
            }
            return instance;
        }
    }
    private Menu() { }
    private static Menu instance;

    public void MSWord()
    {
        MSWordDocument Msdoc = new MSWordDocument("MSWord.doc", "Eugene", "Learning, Doc", "C:/Users/Eugene/Desktop/", 500);
        Msdoc.Info();
    }
    public void PDF()
    {
        PDFDocument Pdfdoc = new PDFDocument("PDFdoc.pdf", "Pavel", "Learning, PDF", "C:/Users/Pavel/Desktop/", 20);
        Pdfdoc.Info();

    }
    public void Excel()
    {
        MSExcelDocument Excel = new MSExcelDocument("Excel.exl", "Maria", "Work, Excel", "C:/Users/Maria/Desktop/", 150);
        Excel.Info();
    }
    public void Txt()
    {
        TXTDocument Txtdoc = new TXTDocument("WatchList.txt", "Danil", "Film, Watched, TXT", "C:/Users/Danil/Desktop/", 500);
        Txtdoc.Info();
    }
    public void Html()
    {
        HTMLDocument Htmldoc = new HTMLDocument("AnimeSite.html", "Alex", "Anime, Site, HTML", "C:/Users/Alex/Desktop/", 20);
        Htmldoc.Info();
    }
}

