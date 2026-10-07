using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Membresias
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public bool TusaFit { get; set; }
        public bool SuperaFit { get; set; }
        public bool SanandoFit { get; set; }
        public bool NomasExs { get; set; }

        public ICollection<Pagos>? Pagos { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Clientes { get; set; }

    }
}
