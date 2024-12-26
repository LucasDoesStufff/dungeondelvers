namespace dungeondelvers.Core
{
    /// <summary>
	/// Custom interface which will be used to determine the load order
	/// </summary>
	interface IOrderedLoadable
	{
		void Load();
		void Unload();
		float Priority { get; }
	}
}
