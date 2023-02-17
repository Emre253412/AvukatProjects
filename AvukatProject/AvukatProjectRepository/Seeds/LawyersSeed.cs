using AvukatProjectCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectRepository.Seeds
{
    public class LawyersSeed : IEntityTypeConfiguration<Lawyers>
    {
        public void Configure(EntityTypeBuilder<Lawyers> builder)
        {
            builder.HasData(
                            new Lawyers { Id = 1, Name = "Emre Uğuz",Mail="emreuuguz@gmail.com",About="Ceza Hukukçusu",Password="1234", Photograph="asd",CategoryId = 1,CreatedDate=DateTime.Now },
                            new Lawyers { Id = 2, Name = "Çağrı Şentürk", Mail = "cagrisenturk@gmail.com", About = "Medeni Hukukçusu", Password = "12324", Photograph = "asd", CategoryId = 2, CreatedDate = DateTime.Now },
                            new Lawyers { Id = 3, Name = "Hakan Özdemir", Mail = "hakanozdemır@gmail.com", About = "Borçlar Hukukçusu", Password = "123444", Photograph = "asd", CategoryId = 3, CreatedDate = DateTime.Now });
        }
    }
}
