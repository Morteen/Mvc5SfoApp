using SfoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfoApp.DTO
{
    public class DTOHelper
    {

        #region Elevmapper  
        /// <summary>
        ///  Mapper en elev om til en elevDto
        /// </summary>
        /// <param name="elev"></param>
        /// <returns></returns>
        public static ElevDTO Elevmapper(Elev elev)
        {
            var dtoElev = new ElevDTO();
            dtoElev.ElevId = elev.ElevId;
            dtoElev.Fornavn = elev.Fornavn;
            dtoElev.Etternavn = elev.Etternavn;
            dtoElev.Klasse = elev.Klasse;
            dtoElev.Trinn = elev.Trinn;
            dtoElev.Telefon = elev.Telefon;
            dtoElev.SkoleId = elev.SkoleId;
            return dtoElev;
        }
        /// <summary>
        /// Mapper om en dtoElev til en elev
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Elev DtoToElevMapper(ElevDTO dto)
        {
            Elev elev= new Elev();
            elev.ElevId = dto.ElevId;
            elev.Fornavn = dto.Fornavn;
            elev.Etternavn = dto.Etternavn;
            elev.Klasse = dto.Klasse;
            elev.Trinn = dto.Trinn;
            elev.Telefon = dto.Telefon;
            elev.SkoleId = dto.SkoleId;

            return elev;
        }


        /// <summary>
        /// Mapper om en liste med elever til en liste av dtoElver
        /// </summary>
        /// <param name="elever"></param>
        /// <returns></returns>
        public static List<ElevDTO> ElevListMapper(List<Elev>elever)
        {
            List<ElevDTO>dtoElever= new List<ElevDTO>();
            foreach (var elev in elever)
            {
                dtoElever.Add(Elevmapper(elev));
            }

            return dtoElever;

        }

        public static List<Elev> DtoToEleveList(List<ElevDTO>dtoList)
        {
            List<Elev>elever= new List<Elev>();
            foreach (var dto in dtoList)
            {
                elever.Add(DtoToElevMapper(dto));
            }

            return elever;
        }

        #endregion

        #region AnsattMapper

        /// <summary>
        /// Mapper en ansatt til en DTO
        /// </summary>
        /// <param name="ansatt"></param>
        /// <returns></returns>
        public static AnsattDto MapAnsattToDoDto(Ansatt ansatt)
        {
            AnsattDto dto = new AnsattDto();

            dto.AnsattId = ansatt.AnsattId;
            dto.SkoleId = ansatt.SkoleId;
            dto.Fornavn = ansatt.Fornavn;
            dto.Etternavn = ansatt.Etternavn;
            dto.Username = ansatt.Username;
            dto.Password = ansatt.Password;
          
            return dto;
        }



        public static List<AnsattDto> AnnsattListToDTOList(List<Ansatt>ansatte)
        {
            List<AnsattDto>dtoList= new List<AnsattDto>();
            foreach (var ansatt in ansatte)
            {
                dtoList.Add(MapAnsattToDoDto(ansatt));
                
            }

            return dtoList;
        }



        #endregion

        public static SjekkInnLoggDto mappOnSjekkInn(SjekkInLogg sjekkInn)
        {
            var dto= new SjekkInnLoggDto();

            DateTime date = Convert.ToDateTime(sjekkInn.SjekkInn);
            dto.SkoleId = sjekkInn.SkoleId;
            dto.ElevId = sjekkInn.ElevId;
            dto.AnsattId = sjekkInn.AnsattId;
            dto.Info = sjekkInn.Info;
            if (10 > Int32.Parse(date.Minute.ToString()))
            {
                dto.SjekkInn = date.Hour.ToString() + ":0" + date.Minute.ToString();

            }
            else { dto.SjekkInn = date.Hour.ToString() + ":" + date.Minute.ToString(); }
           
            dto.SjekkUt = "11";
            dto.Aar = date.Year.ToString();
            dto.Dato = date.Day.ToString()+":"+date.Month.ToString();
            dto.AnsattNavn = sjekkInn.Ansatt.Fornavn + " " + sjekkInn.Ansatt.Etternavn;


            return dto;
        }

        public static List<SjekkInnLoggDto> toSjekkinnDtoList(List<SjekkInLogg> logg)
        {
            var dto = new List<SjekkInnLoggDto>();

            foreach (var sjekk in logg)
            {
                dto.Add(mappOnSjekkInn(sjekk));
            }



            return dto;

        }

        //fra dto til vanlig
        public static SjekkInLogg mapInnsjekkDto(SjekkInnLoggDto dto)
        {    var sjekkInn= new SjekkInLogg();
            sjekkInn.SkoleId = dto.SkoleId;
            sjekkInn.ElevId = dto.ElevId;
            sjekkInn.AnsattId = dto.AnsattId;
            sjekkInn.Info = dto.Info;
            sjekkInn.SjekkInn = dto.SjekkInn;
           
            


            return sjekkInn;
        }
    }
}