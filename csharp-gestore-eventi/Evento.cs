using System;
namespace csharp_gestore_eventi
{
	public class Evento
	{
        public string Titolo { get; set; }
        public DateTime Data { get; set; }
        public int MaxCapienza { get; init; }
        public int NumPrenotazioni { get; private set; }

    }
}

