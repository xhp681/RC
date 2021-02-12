using System.Threading.Tasks;

namespace Rs.Ply.Framework.Themes
{
    public interface IThemeContext
    {
        /// <summary>
        /// Get current theme system name
        /// </summary>
        Task<string> GetWorkingThemeNameAsync();

        /// <summary>
        /// Set current theme system name
        /// </summary>
        Task SetWorkingThemeNameAsync(string workingThemeName);
    }
}