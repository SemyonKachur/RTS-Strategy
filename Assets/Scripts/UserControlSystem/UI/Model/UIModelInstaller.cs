using System.ComponentModel;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class UIModelInstaller : MonoInstaller
    {
        [SerializeField] private AssetsContext _legacyContext;
        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private AttackableValue _attackableClicksRMB;
        [SerializeField] private SelectableValue _selectables;
        public override void InstallBindings()
        {
            Container.BindInstances(_legacyContext, _groundClicksRMB,
                _attackableClicksRMB, _selectables);
            
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
                .To<ProduceUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
                .To<AttackCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
                .To<MoveCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>()
                .To<PatrolCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>()
                .To<StopCommandCommandCreator>().AsTransient();
            
            Container.Bind<CommandButtonsModel>().AsTransient();
        }

        
        // public override void InstallBindings()
        // {
        //     Container.Bind<TransformValue>().FromInstance(_transformValue);
        //     Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        //     Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        //
        //     Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
        //         .To<ProduceUnitCommandCommandCreator>().AsTransient();
        //     Container.Bind<CommandCreatorBase<IAttackCommand>>()
        //         .To<AttackCommandCommandCreator>().AsTransient();
        //     Container.Bind<CommandCreatorBase<IMoveCommand>>()
        //         .To<MoveCommandCommandCreator>().AsTransient();
        //     Container.Bind<CommandCreatorBase<IPatrolCommand>>()
        //         .To<PatrolCommandCommandCreator>().AsTransient();
        //     Container.Bind<CommandCreatorBase<IStopCommand>>()
        //         .To<StopCommandCommandCreator>().AsTransient();
        //     
        //     Container.Bind<CommandButtonsModel>().AsTransient();
        // }
    }
}