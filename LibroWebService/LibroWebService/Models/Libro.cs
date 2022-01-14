using System;
using System.Collections.Generic;



namespace LibroWebService.Models
{
    public partial class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
    }
}
