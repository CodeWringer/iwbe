using System;

namespace iwbe.business.dataaccess.dto
{
    /// <summary>
    /// Marks a business model class as JSON (de-/)serializable. 
    /// </summary>
    /// <typeparam name="T1">Type of the serializable. </typeparam>
    /// <typeparam name="T2">Type of the DTO equivalent. </typeparam>
    internal interface ISerializable<T1, T2>
    {
        /// <summary>
        /// Converts from the given DTO into an instance of <typeparamref name="T1"/>. 
        /// </summary>
        /// <param name="dto">The DTO to convert from. </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        static T1 FromDto(T2 dto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts this instance to a DTO representation. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        T2 ToDto();
    }
}
