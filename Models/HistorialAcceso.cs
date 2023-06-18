using System;
using System.Collections.Generic;

namespace Loor_Lalama.Models;

public partial class HistorialAcceso
{
    public int Id { get; set; }

    public DateTime FechaHora { get; set; }

    public int UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
