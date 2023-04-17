using System;
namespace csharp_gestore_eventi
{
	public class ProgrammaEventi
	{
        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            Eventi = new List<Evento>();
        }

        public string Titolo { get; set; }
        public List<Evento> Eventi { get; set; }

        public void AddEvento(Evento evento)
        {
            Eventi.Add(evento);
        }

        public List<Evento> FilterByData(DateTime data)
        {
            List<Evento> res = new List<Evento>();
            foreach (Evento evento in Eventi)
            {
                if (evento.Data == data)
                {
                    res.Add(evento);
                }
            }
            return res;
        }

        public int GetProgramLenght()
        {
            return Eventi.Count;
        }

        public void ClearProgramList()
        {
            Eventi.Clear();
        }

        public void GetStringProgramma()
        {
            Console.WriteLine($"Titolo del programma: {Titolo}");
            Console.WriteLine();
            foreach (Evento evento in Eventi)
            {
                string res = evento.ToString();
                Console.WriteLine(res.PadLeft(res.Length + 5));
            }
        }
    }
}

