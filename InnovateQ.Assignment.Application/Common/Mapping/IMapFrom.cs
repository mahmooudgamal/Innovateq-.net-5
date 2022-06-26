using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Application.Common.Mapping
{
    public interface IMapFrom<T>
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Mappings the given profile. </summary>
        ///
        /// <param name="profile">  The profile. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
