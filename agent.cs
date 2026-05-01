using Memory; // Verifique se a referência foi adicionada no projeto
using System;
using System.Linq;
using System.Net;
using System.Threading;

public class Runner // Nome da classe que o PowerShell vai chamar
{

    public async static void Execute() // Nome do método
    {
        Mem m = new Mem();
        WebClient wc = new WebClient();
        string linkGist = "https://gist.githubusercontent.com/wyllzzxc/0812e805ef7c7b333236bc58554bc1f5/raw/dbbc8f321831b6b1b93a1475435496f0449987ec/status.txt";

        m.OpenProcess("HD-Player");

        var Scan = await m.AoBScan("FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 A5 43", true, true);
        {
            foreach (var current in Scan)
            {
                Int64 rep1 = current + 170L;
                Int64 rep2 = current + 166L;
                ;

                var Readmem = m.ReadMemory<int>(rep1.ToString("X"));

                m.WriteMemory(rep2.ToString("X"), "int", Readmem.ToString());
            }
        }





        Console.Beep();
    }
};

