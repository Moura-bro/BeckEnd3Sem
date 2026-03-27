using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus_Moura.Models;

[Table("Contado")]
public partial class Contado
{
    [Key]
    public Guid IdContato { get; set; }

    [StringLength(255)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    public string FormaContato { get; set; } = null!;

    [StringLength(255)]
    public string? Imagens { get; set; }

 

    public Guid? IdTipoContato { get; set; }

    [ForeignKey("IdTipoContato")]
    [InverseProperty("Contados")]
    public virtual TipoContato? IdTipoContatoNavigation { get; set; }
}
