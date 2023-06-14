using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManager.Data.Entities
{

    internal class LinePropertiesDomain: ViewModels.Base.ViewModel
    {
        private int id;
        private int lineId;
        private List<Reductions> reductions;
        private string? remarks;
        private List<TapOffBoxes>? boxes;
        private int fixingHangers;
        private int? centerBoxes;
        private int? endBoxes;
        private int? expJoints;
        private int? endCaps;
        private int? fireBarriers;
        private int? tElbows;
        private int? termTr;
        private int? termSwg;
        private int? elbows;
        private float length;
        private string iP;
        private int orderNumber;

        public int Id
        {
            get { return id; }
        }
        public int LineId
        {
            get { return lineId; }
            set => Set(ref lineId, value);
        }
        public int OrderNumber
        {
            get { return orderNumber; }
            set => Set(ref orderNumber, value);
        }
        public string IP
        {
            get { return iP; }
            set => Set(ref iP, value);
        }

        public float Length
        {
            get { return length; }
            set => Set(ref length, value);
        }
        public int? Elbows
        {
            get { return elbows; }
            set => Set(ref elbows, value);
        }
        public int? TermSwg
        {
            get { return termSwg; }
            set => Set(ref termSwg, value);
        }
        public int? TermTr
        {
            get { return termTr; }
            set => Set(ref termTr, value);
        }
        public int? TElbows
        {
            get { return tElbows; }
            set => Set(ref tElbows, value);
        }
        public int? FireBarriers
        {
            get { return fireBarriers; }
            set => Set(ref fireBarriers, value);
        }
        public int? EndCaps
        {
            get { return endCaps; }
            set => Set(ref endCaps, value);
        }
        public int? ExpJoints
        {
            get { return expJoints; }
            set => Set(ref expJoints, value);
        }
        public int? EndBoxes
        {
            get { return endBoxes; }
            set => Set(ref endBoxes, value);
        }
        public int? CenterEndBoxes
        {
            get { return centerBoxes; }
            set => Set(ref centerBoxes, value);
        }
        public int FixingHangers
        {
            get { return fixingHangers; }
            set => Set(ref fixingHangers, value);
        }

        public List<TapOffBoxes>? Boxes
        {
            get { return boxes; }
            set => Set(ref boxes, value);
        }

        public string? Remarks
        {
            get { return remarks; }
            set => Set(ref remarks, value);
        }
        public List<Reductions>? Reductions
        {
            get { return reductions; }
            set => Set(ref reductions, value);
        }

    }
}
