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


    }
}