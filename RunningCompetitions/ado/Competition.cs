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
    
    public partial class Competition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competition()
        {
            this.Result_competition = new HashSet<Result_competition>();
        }
    
        public int ID_competition { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Date_of_the_event { get; set; }
        public Nullable<int> ID_venue { get; set; }
        public Nullable<int> ID_type_running { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result_competition> Result_competition { get; set; }
        public virtual Type_running Type_running { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
