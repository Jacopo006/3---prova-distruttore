using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3___prova_distruttore
{
    internal class Program
    {
        static void Main()
        {
            // Creazione di un'istanza della classe "Esempio"
            using (Esempio esempio = new Esempio("Hello", 42))
            {
                // Utilizzo dell'istanza
                Console.WriteLine("Stringa: {0}, Numero: {1}", esempio.GetStringa(), esempio.GetNumero());
            } // Qui verrà chiamato automaticamente Dispose() quando esce dal blocco using

            // Chiamata esplicita al Garbage Collector
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Fine del programma.");
        }
    }

    class Esempio : IDisposable
    {
        private string stringa;
        private int numero;

        // Costruttore
        public Esempio(string inputStringa, int inputNumero)
        {
            stringa = inputStringa;
            numero = inputNumero;
            Console.WriteLine("Oggetto creato. Stringa: {0}, Numero: {1}", stringa, numero);
        }

        // Metodo accessor per la stringa
        public string GetStringa()
        {
            return stringa;
        }

        // Metodo accessor per il numero
        public int GetNumero()
        {
            return numero;
        }

        // Metodo Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Distruttore
        ~Esempio()
        {
            Dispose(false);
        }

        // Implementazione del metodo Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Rilascia le risorse gestite
                Console.WriteLine("Risorse gestite rilasciate.");
            }

            // Rilascia le risorse non gestite
            Console.WriteLine("Risorse non gestite rilasciate.");
        }
    }    
}
