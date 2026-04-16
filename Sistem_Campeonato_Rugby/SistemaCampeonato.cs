using System;
using System.Collections.Generic;
using System.Text;

namespace Sistem_Campeonato_Rugby
{
    public class SistemaCampeonato
    {
        
    }
    //============
    //JOGADORES
    //============
    public class Player
    {
        private string name;
        public void setNome (string n) {
            this.name = n;
        }
        public string getNome()
        {
            return this.name;
        }
    }
}
