//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RunningCompetitions.ado
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sponsor_command
    {
        public int ID_sponsor_command { get; set; }
        public int ID_sponsor { get; set; }
        public int ID_command { get; set; }
        public Nullable<int> Team_of_the_contract { get; set; }
        public Nullable<int> Amount_per_year { get; set; }
    
        public virtual Command Command { get; set; }
        public virtual Sponsor Sponsor { get; set; }
    }
}
