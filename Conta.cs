using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAtendimentoBancario
{
    class Conta
    {
        public string titular { get; set; }
        public double saldo { get; set; }
        public int numConta { get; set; }
        public double chequeEspecial { get; set; }

        public Conta(string titular, int conta, double saldo)
        {
            this.titular = titular;
            this.numConta = conta;
            this.saldo = saldo;
            this.chequeEspecial = 300;
        }


    }
}
