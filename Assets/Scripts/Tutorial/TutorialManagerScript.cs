using System;
using UnityEngine;

namespace Tutorial
{
    public class TutorialManagerScript : MonoBehaviour
    {
        public GameObject movementTutorialPanel;
        public GameObject attackTutorialPanel;
        public GameObject controlNodeTutorialPanel;
        public GameObject weakspotTutorialPanel;
        public GameObject startTutorialPanel;
        private TutorialStep _currentStep;

        private bool _shouldListenForMovement = false;
        private bool _shouldListenForAttack = false;
        private bool _shouldListenForSpacebar = false;

        private enum TutorialStep
        {
            TeachMovement,
            TeachAttack,
            TeachControlNodes,
            TeachWeakspot,
            StartTutorial,
            TutorialOver
        }
        
        private void Awake()
        {
            movementTutorialPanel.SetActive(false);
            attackTutorialPanel.SetActive(false);
            controlNodeTutorialPanel.SetActive(false);
            weakspotTutorialPanel.SetActive(false);
            startTutorialPanel.SetActive(false);
        }

        private void Start()
        {
            SetTutorialStep(TutorialStep.TeachMovement);
        }

        private void SetTutorialStep(TutorialStep nextStep)
        {
            _currentStep = nextStep;
            ExecuteStepTransition();
        }

        private void ExecuteStepTransition()
        {
            switch (_currentStep)
            {
                case TutorialStep.TeachMovement:
                    movementTutorialPanel.SetActive(true);
                    _shouldListenForMovement = true;
                    break;
                case TutorialStep.TeachAttack:
                    _shouldListenForMovement = false;
                    movementTutorialPanel.SetActive(false);
                    attackTutorialPanel.SetActive(true);
                    _shouldListenForAttack = true;
                    break;
                case TutorialStep.TeachWeakspot:
                    _shouldListenForAttack = false;
                    attackTutorialPanel.SetActive(false);
                    weakspotTutorialPanel.SetActive(true);
                    _shouldListenForSpacebar = true;
                    break;
                case TutorialStep.TeachControlNodes:
                    weakspotTutorialPanel.SetActive(false);
                    controlNodeTutorialPanel.SetActive(true);
                    break;
                case TutorialStep.StartTutorial:
                    controlNodeTutorialPanel.SetActive(false);
                    startTutorialPanel.SetActive(true);
                    break;
                case TutorialStep.TutorialOver:
                    startTutorialPanel.SetActive(false);
                    EndTutorial();
                    break;
            }
        }

        private void LateUpdate()
        {
            if (_shouldListenForMovement)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
                {
                     SetTutorialStep(TutorialStep.TeachAttack);
                }
            }
            else if (_shouldListenForAttack && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)))
            {
                SetTutorialStep(TutorialStep.TeachWeakspot);
            }
            else if (_shouldListenForSpacebar && Input.GetKeyDown(KeyCode.Space))
            {
                switch (_currentStep)
                {
                    case(TutorialStep.TeachWeakspot):
                        SetTutorialStep(TutorialStep.TeachControlNodes);
                        break;
                    case(TutorialStep.TeachControlNodes):
                        SetTutorialStep(TutorialStep.StartTutorial);
                        break;
                    case(TutorialStep.StartTutorial):
                        SetTutorialStep(TutorialStep.TutorialOver);
                        break;
                }
            }
        }

        public void EndTutorial()
        {
            Destroy(GameObject.FindWithTag("TutorialUI"));
            Destroy(GameObject.FindWithTag("TutorialManager"));
        }
    }
}
