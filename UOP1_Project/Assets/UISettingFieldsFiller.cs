using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class UISettingFieldsFiller : MonoBehaviour
{
	[SerializeField]
	private UISettingItemFiller[] _settingfieldsList = default;
	public void FillFields(List<settingField> settingItems)
	{
		for (int i = 0; i < _settingfieldsList.Length; i++)
		{
			if(i< settingItems.Count)
			{
				SetField(settingItems[i], _settingfieldsList[i]);
				_settingfieldsList[i].gameObject.SetActive(true);
			}
			else
			{

				_settingfieldsList[i].gameObject.SetActive(false);
			}
		}

	}
	public void SelectFields(settingTabType tabType)
	{
		

	}

	public void SetField(settingField field, UISettingItemFiller uiField)
	{
		int paginationCount=0;
		int selectedPaginationIndex=0;
		string selectedOption=default;
		LocalizedString fieldTitle=field.title;
		settingFieldType fieldType= field.settingFieldType;
		
			switch (field.settingFieldType)
		{
			case settingFieldType.Language:
				paginationCount = LocalizationSettings.AvailableLocales.Locales.Count;
				selectedPaginationIndex = LocalizationSettings.AvailableLocales.Locales.FindIndex(o => o == LocalizationSettings.SelectedLocale);
				selectedOption = LocalizationSettings.SelectedLocale.LocaleName; 
				break;
			case settingFieldType.AntiAliasing:

				break;
			case settingFieldType.FullScreen:
				selectedPaginationIndex = IsFullscreen();
				paginationCount = 2;
				if (Screen.fullScreen)
					selectedOption = "On";
				else
					selectedOption = "Off";
				break;
			case settingFieldType.GraphicQuality:
				selectedPaginationIndex = QualitySettings.GetQualityLevel(); 
				paginationCount = 6;
				selectedOption = QualitySettings.names[QualitySettings.GetQualityLevel()]; 
				break;
			case settingFieldType.Resolution:

				break;
			case settingFieldType.Shadow:

				break;
			case settingFieldType.Volume_Music:
			case settingFieldType.Volume_SFx:
				 paginationCount = 10;
				 selectedPaginationIndex = 5;
				 selectedOption = "5"; 
				 break;



		}
		uiField.SetSettingField(paginationCount, selectedPaginationIndex, selectedOption, fieldTitle, fieldType); 


	}
	string GetQualityLevelTitle()
	{
		string title = ""; 
		switch (QualitySettings.GetQualityLevel())
		{

			case (int) QualityLevel.Beautiful:
				title = QualityLevel.Beautiful.ToString(); 
				break;
			case (int)QualityLevel.Fantastic:
				title = QualityLevel.Fantastic.ToString();
				break;
			case (int)QualityLevel.Fast:
				title = QualityLevel.Fast.ToString();

				break;
			case (int)QualityLevel.Fastest:
				title = QualityLevel.Fastest.ToString();

				break;
			case (int)QualityLevel.Good:
				title = QualityLevel.Good.ToString();

				break;
			case (int)QualityLevel.Simple:
				title = QualityLevel.Simple.ToString();

				break;




		}
		return title;

	}
	int IsFullscreen()
	{
		if(Screen.fullScreen)
		{
			return 0; 
		}else
		{
			return 1; 
		}

	}
}
