using mas_project.Models;
using mas_project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mas_project.DTO
{
    public class PlaygroundDTO
    {
        public int PlaygroundId { get; set; }
        public string address { get; set; }
        public string descriptionOfLand { get; set; }
        public decimal surface { get; set; }
        public bool fenced { get; set; }
        public decimal fenceHeight { get; set; }
        public DateTime DateOfCompletionActual { get; set; }
        public decimal? DownPayment { get; set; }
        public Status Status { get; set; }
        public Playground playground { get; set; }

        public PlaygroundDTO(Playground playground) 
        {
            this.PlaygroundId = playground.PlaygroundId;
            this.address = playground.address;
            this.descriptionOfLand = playground.descriptionOfLand;
            this.surface = playground.surface;
            this.fenced = playground.fenced;
            this.fenceHeight = playground.fenceHeight;
            this.DateOfCompletionActual = playground.Contract.DateOfCompletionActual;
            this.DownPayment = playground.Contract.DownPayment;
            this.Status = playground.Contract.Status;
            this.playground = playground;
        }
    }
}
