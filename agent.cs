using System;
using System.Net;
using System.Linq;
using System.Threading;
using Memory;

public class Runner {
    public static void Execute() {
        Mem memory = new Mem();
        WebClient wc = new WebClient();
        // Substitua pelo link RAW do seu Gist
        string linkGist = "https://gist.githubusercontent.com/wyllzzxc/0812e805ef7c7b333236bc58554bc1f5/raw/dbbc8f321831b6b1b93a1475435496f0449987ec/status.txt"; 

        while (true) {
            try {
                // Tenta abrir o processo do emulador
                if (memory.OpenProcess("HD-Player")) {
                    string comando = wc.DownloadString(linkGist).Trim();

                    if (comando == "1") {
                        // AOB do emulador é longo, usamos .Result para o PowerShell não quebrar
                        string aob = "FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43";
                        
                        var Scan = memory.AoBScan(aob, true, true).Result;

                        if (Scan != null && Scan.Count() > 0) {
                            foreach (var current in Scan) {
                                long rep1 = current + 0xB8;
                                long rep2 = current + 0xB4;

                                // Lê e escreve conforme sua lógica
                                int Readmem = memory.ReadInt(rep1.ToString("X"));
                                memory.WriteMemory(rep2.ToString("X"), "int", Readmem.ToString());
                            }
                            Console.Beep(); // Feedback sonoro no PC
                        }
                    }
                    if (comando == "9") Environment.Exit(0);
                }
            } catch { }
            Thread.Sleep(4000); // Delay maior para evitar lag no emulador
        }
    }
}
