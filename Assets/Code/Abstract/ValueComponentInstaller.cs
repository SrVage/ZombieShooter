using System;
using System.Linq;
using System.Reflection;
using Code.Utils;
using Leopotam.Ecs;

namespace Code.Abstract
{
	public abstract class ValueComponentInstaller<T> : ComponentInstallerBase where T : struct
	{
		public override void InitComponent(EcsEntity entity)
		{
			ref var component = ref entity.Get<T>();
			InjectFields(this, ref component);
		}

		private void InjectFields(ValueComponentInstaller<T> source, ref T target)
		{
			var targetFields = GetTargetFields(target);

			var sourceFields = GetSourceFields(source);

			foreach (var field in targetFields)
			{
				var sourceField = FindSourceFieldWithWaitingName(field, sourceFields);

				if (sourceField != null)
				{
					object value = sourceField.GetValue(source);
					TypedReference reference = __makeref(target);
					field.SetValueDirect(reference, value);
				}
			}
		}

		private static FieldInfo FindSourceFieldWithWaitingName(FieldInfo field, FieldInfo[] sourceFields)
		{
			var waitingFieldName = field.GetCustomAttribute<InjectFieldAttribute>().FieldName;
			var sourceField = sourceFields.FirstOrDefault(f => f.Name == waitingFieldName);
			return sourceField;
		}

		private static FieldInfo[] GetSourceFields(ValueComponentInstaller<T> source)
		{
			Type sourceType = source.GetType();
			FieldInfo[] sourceFields = sourceType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			return sourceFields;
		}

		private static FieldInfo[] GetTargetFields(T target)
		{
			Type targetType = target.GetType();
			FieldInfo[] targetFields = targetType.GetFields(BindingFlags.Public | BindingFlags.Instance);
			targetFields = targetFields.Where(t => t.GetCustomAttribute<InjectFieldAttribute>() != null).ToArray();
			return targetFields;
		}
	}
}