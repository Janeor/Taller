using System;
using System.Collections.Generic;

namespace Loor_Lalama.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public bool Estado { get; set; }

    public int GeneroId { get; set; }

    public virtual Genero Genero { get; set; } = null!;

    public virtual ICollection<HistorialAcceso> HistorialAccesos { get; set; } = new List<HistorialAcceso>();
}
