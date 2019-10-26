using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Entities
{
    public class RoomMessage : Entities.BaseEntity
    {
        public Guid Room_Id { get; set; }
        [ForeignKey(nameof(Room_Id))]
        public Room Room { get; set; }

        public Guid Message_Id { get; set; }
        [ForeignKey(nameof(Message_Id))]

        public Message Message { get; set; }
    }
}