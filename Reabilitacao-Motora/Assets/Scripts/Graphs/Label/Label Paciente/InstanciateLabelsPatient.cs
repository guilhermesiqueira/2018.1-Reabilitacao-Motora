using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using pontosrotulopaciente;

public class InstanciateLabelsPatient : MonoBehaviour 
{
	[SerializeField]
	protected GameObject labelPrefab;


	void ButtonSpawner(PontosRotuloPaciente prp)
	{
		GameObject go = Instantiate(labelPrefab, transform);

		var aux = go.GetComponentInChildren<SetLabelPatient>();
		aux.Prp = prp;

		var scriptInitial = go.GetComponentInChildren<SetInitialX>();
		var scriptFinal = go.GetComponentInChildren<SetFinalX>();
		var labelName = go.GetComponentInChildren<TextMesh>();

		scriptInitial.InitialX = prp.tempoInicial;
		scriptFinal.FinalX = prp.tempoFinal;

		scriptInitial.Set();
		scriptFinal.Set();

		labelName.text = prp.estagioMovimentoPaciente;
	}

	public void Awake ()
	{
		List<PontosRotuloPaciente> prps = PontosRotuloPaciente.Read();
		foreach (var prp in prps)
		{
			if (prp.idExercicio == GlobalController.instance.exercise.idExercicio)
			{
				ButtonSpawner(prp);
			}
		}
	}
}
