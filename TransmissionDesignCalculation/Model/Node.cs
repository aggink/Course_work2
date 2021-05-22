using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Базы_данных.Курсовая_работа.Model
{
    public class Node
    {
        public Guid NodeId { get; set; }
        public List<Gear> gear = null;
        public bool save { get; set; } = false;
        public Node()
        {
            gear = new List<Gear>();
        }

        public Node(List<AllData> alldata)
        {
            this.gear = new List<Gear>();
            this.save = true;

            foreach (var all in alldata)
            {
                this.NodeId = all.NodeId;
                Gear gear = new Gear();
                gear.N = all.N;
                gear.GearId = all.GearId;
                gear.n = all.n;
                gear.n1 = all.n1;
                gear.t_r = all.t_r;
                gear.N_FE = all.N_FE;
                gear.N_HE = all.N_HE;
                gear.TypeGear = all.TypeGear;
                gear.TypeLoad_p = all.TypeLoad_p;
                gear.TypeLoad_r = all.TypeLoad_r;
                gear.TypeSupport = all.TypeSupport;
                gear.save = true;

                gear.detail = new Detail();
                gear.detail.beta_m = all.beta_m;
                gear.detail.delta1 = all.delta1;
                gear.detail.delta2 = all.delta2;
                gear.detail.gearId = all.gearId;
                gear.detail.Mark = all.Mark;
                gear.detail.Material = all.Material;
                gear.detail.MaterialId = all.MaterialId;
                gear.detail.save = true;
                gear.detail.TypeHardening = all.TypeHardening;
                gear.detail.TypeTeeth = all.TypeTeeth;
                gear.detail.TypeTeeth_z = all.TypeTeeth_z;
                gear.detail.wheelId = all.wheelId;
                gear.detail.z1 = all.z1;
                gear.detail.z2 = all.z2;
                this.gear.Add(gear);
            }

        }
    }
}
