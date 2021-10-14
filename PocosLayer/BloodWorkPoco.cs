using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace MedChart.PocosLayer
{
    [Table("Blood_Work")]
    public class BloodWorkPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [Column("date_created")]
        [Required(ErrorMessage = "Created Date is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
        [Column("exam_date")]
        [Required(ErrorMessage = "Exam Date is required.")]
        public DateTime ExamDate { get; set; }
        [Column("results_date")]
        public DateTime? ResultsDate { get; set; }
        [Column("description")]
        [Required(ErrorMessage ="A description is required.")]
        public string Description { get; set; }
        [Column("hemoglobin", TypeName = "decimal(6,4)")]
        [Required(ErrorMessage = "Hemoglobin level is required.")]
        [Range(0.001, 100, ErrorMessage = "Value has to be a positive number")]
        public decimal Hemoglobin { get; set; }
        [Column("hematocrit", TypeName = "decimal(6,4)")]
        [Required(ErrorMessage = "Hematocrit value is required.")]
        [Range(0.001, 100, ErrorMessage = "Value has to be a positive number")]
        public decimal Hematocrit { get; set; }
        [Column("white_blood_cell_count_mcpmcl", TypeName = "decimal(6,4)")]
        [Required(ErrorMessage = "White blood cell count is required.")]
        [Range(0.001, 100, ErrorMessage = "Value has to be a positive number")]
        public decimal WhiteBloodCellCountMCPMcL { get; set; }
        [Column("red_blood_cell_count_mcpmcl", TypeName = "decimal(6,4)")]
        [Required(ErrorMessage = "Red blood cell count is required.")]
        [Range(0.001, 100, ErrorMessage = "Value has to be a positive number")]
        public decimal RedBloodCellCountMCPMcL { get; set; }
    }
}
