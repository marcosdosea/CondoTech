using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Condominio
    {
        public Condominio()
        {
            Administradores = new HashSet<Administradores>();
            Areacomum = new HashSet<Areacomum>();
            Aviso = new HashSet<Aviso>();
            Condomino = new HashSet<Condomino>();
            Execucaotarefarecorrente = new HashSet<Execucaotarefarecorrente>();
            Ocorrencias = new HashSet<Ocorrencias>();
        }

        public int IdCondominio { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int? Numero { get; set; }
        public string Cep { get; set; }

        public virtual ICollection<Administradores> Administradores { get; set; }
        public virtual ICollection<Areacomum> Areacomum { get; set; }
        public virtual ICollection<Aviso> Aviso { get; set; }
        public virtual ICollection<Condomino> Condomino { get; set; }
        public virtual ICollection<Execucaotarefarecorrente> Execucaotarefarecorrente { get; set; }
        public virtual ICollection<Ocorrencias> Ocorrencias { get; set; }
    }
}
