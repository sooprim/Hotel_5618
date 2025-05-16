using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Service.DTOs
{
    public class GuestDto
    {
        [DefaultValue(1)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [DefaultValue("Jovan")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(400)]
        [DefaultValue("Tone")]
        public string LastName { get; set; }

        [Required]
        [DefaultValue("2004-04-28")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(600)]
        [DefaultValue("Street 21, Temecula")]
        public string Address { get; set; }

        [Required]
        [DefaultValue("American")]
        public string Nationality { get; set; }

        [Required]
        [DefaultValue("2025-05-15")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DefaultValue("2025-05-20")]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [DefaultValue(1)]
        public int RoomId { get; set; }
    }

    public class CreateGuestDto
    {
        [Required]
        [MaxLength(200)]
        [DefaultValue("Jovan")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(400)]
        [DefaultValue("Tone")]
        public string LastName { get; set; }

        [Required]
        [DefaultValue("2004-04-28")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(600)]
        [DefaultValue("Street 21, Temecula")]
        public string Address { get; set; }

        [Required]
        [DefaultValue("American")]
        public string Nationality { get; set; }

        [Required]
        [DefaultValue("2025-05-15")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DefaultValue("2025-05-20")]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [DefaultValue(1)]
        public int RoomId { get; set; }
    }

    public class UpdateGuestDto
    {
        [Required]
        [MaxLength(200)]
        [DefaultValue("Jovan")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(400)]
        [DefaultValue("Tone")]
        public string LastName { get; set; }

        [Required]
        [DefaultValue("2004-04-28")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(600)]
        [DefaultValue("Street 21, Temecula")]
        public string Address { get; set; }

        [Required]
        [DefaultValue("American")]
        public string Nationality { get; set; }

        [Required]
        [DefaultValue("2025-05-15")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DefaultValue("2025-05-20")]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [DefaultValue(1)]
        public int RoomId { get; set; }
    }
} 