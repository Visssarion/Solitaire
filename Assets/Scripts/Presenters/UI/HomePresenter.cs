using Solitaire.Models;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Solitaire.Presenters
{
    public class HomePresenter : OrientationAwarePresenter
    {
        [SerializeField] Button _buttonNewMatch;
        [SerializeField] Button _buttonContinue;
        [SerializeField] Button _buttonOptions;
        [SerializeField] RectTransform _rectCards;

        [Inject] Game _game;
        [Inject] GamePopup _gamePopup;

        protected override void Start()
        {
            base.Start();

            _game.NewMatchCommand.BindTo(_buttonNewMatch).AddTo(this);
            _game.ContinueCommand.BindTo(_buttonContinue).AddTo(this);
            _gamePopup.OptionsCommand.BindTo(_buttonOptions).AddTo(this);
        }

        protected override void OnOrientationChanged(bool isLandscape)
        {
            _rectCards.anchoredPosition = isLandscape ? new Vector2(0, -120) : Vector2.zero;
        }
    }
}
