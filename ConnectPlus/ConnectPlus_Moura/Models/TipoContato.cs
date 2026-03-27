using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus_Moura.Models;

[Table("TipoContato")]
public partial class TipoContato
{
    [Key]
    public Guid IdTipoContato { get; set; }

    [StringLength(255)]
    public string Titulo { get; set; } = null!;

    [InverseProperty("IdTipoContatoNavigation")]
    public virtual ICollection<Contado> Contados { get; set; } = new List<Contado>();
}
