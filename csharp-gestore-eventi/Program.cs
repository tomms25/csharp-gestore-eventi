// See https://aka.ms/new-console-template for more information
using csharp_gestore_eventi;

Console.WriteLine("Hello, World!");

List<Evento> eventi = new List<Evento>();

Console.WriteLine("Benvenuti sul portale Eventi.");
Console.WriteLine("Per creare un nuovo evento è necessario inserire un titolo:");
var titolo = Console.ReadLine();
Console.WriteLine("Inserire la data dell'evento:");
var data = Console.ReadLine();
Console.WriteLine("Inserisci il numero di posti totali dell'evento:");
var postiTot = Console.ReadLine();

try
{
    var eventoSelezionato = new Evento(titolo, data, postiTot);
    eventi.Add(eventoSelezionato);
    Console.WriteLine("Evento inserito correttamente.");
    Console.WriteLine();
    Console.WriteLine("Ora è possibile preotare dei posti per questo evento. Desideri farlo? (si/NO)");
    var siNo = Console.ReadLine();
    if (siNo == "si")
    {
        eventoSelezionato.Prenotazione();
    }
    if (eventoSelezionato.NumPrenotazioni > 0)
    {
        Console.WriteLine("Ora è possibile disdire dei posti per questo evento. Desideri farlo? (si/NO)");
        var siNo1 = Console.ReadLine();
        if (siNo1 == "si")
        {
            eventoSelezionato.Disdetta();
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("Ora è possibile creare un Programma di Eventi.");
Console.WriteLine("Inserire il nome del Programma di Eventi:");
var titoloProgramma = Console.ReadLine();

ProgrammaEventi programma = new ProgrammaEventi(titoloProgramma);

Console.WriteLine();
Console.WriteLine("Ora è possibile inserire degli eventi al programma, qual è il numero di eventi?");
int numEventi = 0;

try
{
    numEventi = Convert.ToInt32(Console.ReadLine());

}
catch
{
    Console.WriteLine("Numero eventi non inserito correttamente.");
}

for (int i = 0; i < numEventi; i++)
{
    Console.WriteLine($"Inserire evento numero: {i + 1}");
    bool eventoInserito = false;
    while (!eventoInserito)
    {
        Console.WriteLine("Inserire un titolo:");
        var titoloEvento = Console.ReadLine();
        Console.WriteLine("Inserire la data dell'evento:");
        var dataEvento = Console.ReadLine();
        Console.WriteLine("Inserisci il numero di posti totali dell'evento:");
        var postiTotEvento = Console.ReadLine();

        try
        {
            programma.Eventi.Add(new Evento(titoloEvento, dataEvento, postiTotEvento));
            Console.WriteLine($"Evento numero {i + 1} creato correttamente");
            eventoInserito = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Riprovare");
        }
    }
}

Console.WriteLine();
Console.WriteLine("Ora è possibile inserire una Conferenza al programma.");


bool conferenzaIns = false;
while (!conferenzaIns)
{
    Console.WriteLine("Inserire un titolo:");
    var titoloConf = Console.ReadLine();
    Console.WriteLine("Inserire la data dell'evento:");
    var dataConf = Console.ReadLine();
    Console.WriteLine("Inserisci il numero di posti totali dell'evento:");
    var postiTotConf = Console.ReadLine();
    Console.WriteLine("Inserisci il relatore dell'evento:");
    var relatore = Console.ReadLine();
    Console.WriteLine("Inserisci il prezzo dell'evento:");
    var prezzo = Console.ReadLine();

    try
    {
        programma.Eventi.Add(new Conferenza(titoloConf, dataConf, postiTotConf, relatore, prezzo));
        Console.WriteLine("Conferenza creata correttamente");
        conferenzaIns = true;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Riprovare");
    }
}



if (programma.Eventi.Count > 0)
{
    Console.WriteLine($"Numero di eventi inseriti: {programma.GetProgramLenght()}");
    Console.WriteLine();
    programma.GetStringProgramma();
    Console.WriteLine();
    Console.WriteLine("Inserire una data per filtrare gli eventi:");
    var dataInserita = Console.ReadLine();
    if (DateTime.TryParse(dataInserita, out DateTime res))
    {
        Console.WriteLine();
        var resfix = res.ToString("dd/MM/yyyy");
        Console.WriteLine($"Risultati per eventi in data {resfix}:");
        List<Evento> listaRisultati = programma.FilterByData(res);
        if (listaRisultati.Count > 0)
        {
            foreach (Evento evento in listaRisultati)
            {
                Console.WriteLine(evento.ToString());
            }
        }
        else
        {
            Console.WriteLine("Nessun risultato nella data cercata.");
        }
    }
    else
    {
        Console.WriteLine("Data non inserita correttamente (dd,MM,yyyy).");
    }
}