using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Hotel.Service.DTOs
{
    public class RoomDto
    {
        [DefaultValue(1)]
        public int Id { get; set; }

        [Required]
        [DefaultValue("101")]
        public string Number { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Floor { get; set; }

        [Required]
        [DefaultValue("Single")]
        public string Type { get; set; }
    }

    public class CreateRoomDto
    {
        [Required]
        [DefaultValue("101")]
        public string Number { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Floor { get; set; }

        [Required]
        [DefaultValue("Single")]
        public string Type { get; set; }
    }

    public class UpdateRoomDto
    {
        [Required]
        [DefaultValue("101")]
        public string Number { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Floor { get; set; }

        [Required]
        [DefaultValue("Single")]
        public string Type { get; set; }
    }
} 