using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_shop
{
    internal class Prodotto
    {
        private static readonly HashSet<string> Names = new HashSet<string>();
        public int Code { get; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (Names.Contains(value))
                    throw new Exception("Product name already exists");
                Names.Add(value);
                name = value;
            }
        }
        public string? Description { get; set; }

        public double Price { get; set; }

        private double iva;
        public double Iva
        {
            get { return iva; }
            set { iva = value; }
        }

        private static Random myRandom = new Random();

        public Prodotto(string name, string description, double price, double iva)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Iva = iva;
            Code = myRandom.Next();
        }

        public double GetIvaPrice()
        {
            return Price * (1.0 + Iva);
        }

        public string ExtendedName()
        {
            return String.Format("Code: {0}, Name: {1}, Descrizione: {2}, Prezzo: {3}$", Code, Name, Description, Price);
        }
        public string GetFormattedCode()
        {
            string sCode = Code.ToString();
            if (sCode.Length < 13)
                return new String('0', 13 - sCode.Length) + sCode;
            else
                return sCode;
        }
    }
}