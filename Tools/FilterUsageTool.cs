using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ShandyGecko.LogSystem
{
	public static class FilterUsageTool
	{
		public static IEnumerable<Type> LoadAllFilterTypes()
		{
			var filterTypes = new List<Type>();
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (var assembly in assemblies)
			{
				LoadFilterTypesFromAssembly(assembly, ref filterTypes);
			}
			
			return filterTypes;
		}
		
		public static IEnumerable<string> LoadAllFilterTags()
		{
			var filterTags = new List<string>();
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (var assembly in assemblies)
			{
				LoadFilterTagFieldsFromAssembly(assembly, ref filterTags);
			}

			return filterTags;
		}
		
		private static void LoadFilterTypesFromAssembly(Assembly assembly, ref List<Type> filterTypes)
		{
			var types = assembly.GetTypes();
			foreach (var type in types)
			{
				var hasFilterAttribute = type.GetCustomAttributes<LogFilterAttribute>().Any();

				if (!hasFilterAttribute)
				{
					continue;
				}
				
				filterTypes.Add(type);
			}
		}

		private static void LoadFilterTagFieldsFromAssembly(Assembly assembly, ref List<string> filterTags)
		{
			var types = assembly.GetTypes();
			foreach (var type in types)
			{
				var fields = type.GetFields(BindingFlags.Instance |
				                               BindingFlags.Static |
				                               BindingFlags.Public |
				                               BindingFlags.NonPublic)
					.Where(f => f.GetCustomAttributes<LogFilterAttribute>().Any());
				
				foreach (var field in fields)
				{
					object value;
					try
					{
						value = field.GetValue(null);
					}
					catch (TargetException)
					{
						continue;
					}
					
					filterTags.Add(value.ToString());
				}
			}
		}
	}
}