using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Data.Models
{
    public class Board
    {
        [Key]
        [Comment("Board identifier")]
        public int Id { get; set; }
    }
}
