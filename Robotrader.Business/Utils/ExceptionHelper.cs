using System;
using System.Collections.Generic;
using System.Text;

namespace Robotrader.Business.Utils
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// Throws an ArgumentNullException if argument is null.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="argument">The argument.</param>
        public static void ThrowIfIsNull(string argumentName, object argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Throws an ArgumentNullException if argument is null or an ArgumentException if string is empty.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="argument">The argument.</param>
        public static void ThrowIfIsNullOrEmpty(string argumentName, string argument)
        {
            ThrowIfIsNull(argumentName, argument);

            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentException($"Argument '{argumentName}' can't be empty.");
            }
        }
    }
}
