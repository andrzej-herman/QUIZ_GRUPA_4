using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLogic
{
    public class Pytanie : Base
    {
        public int Kategoria { get; set; }
        public List<Odpowiedz> Odpowiedzi { get; set; } 
    }
}
