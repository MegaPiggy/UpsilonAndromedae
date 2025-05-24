using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace UpsilonAndromedae
{
    public class UpsilonAndromedae : ModBehaviour
    {
        private static UpsilonAndromedae instance;
        public static UpsilonAndromedae Instance => instance;

        public INewHorizons NewHorizonsAPI;

        private void Awake()
        {
            instance = this;
        }

        private void OnStarSystemLoaded(string starSystem)
        {
            if (starSystem.Equals("MegaPiggy.UpsilonAndromedae"))
            {
                Transform player = Locator.GetPlayerTransform();
                if (player != null && player.gameObject != null)
                {
                    PlayerResources resources = player.GetComponent<PlayerResources>();
                    resources._currentFuel *= 4;
                    resources._currentOxygen *= 4;
                    resources._currentHealth *= 2;
                    JetpackThrusterModel thrusterModel = player.GetComponent<JetpackThrusterModel>();
                    thrusterModel._maxTranslationalThrust *= 2;
                    thrusterModel._maxRotationalThrust *= 2;
                }
                Transform ship = Locator.GetShipTransform();
                if (ship != null && ship.gameObject != null)
                {
                    ShipResources resources = ship.GetComponent<ShipResources>();
                    resources._maxFuel *= 4;
                    resources._maxOxygen *= 4;
                    resources._currentFuel = resources._maxFuel;
                    resources._currentOxygen = resources._maxOxygen;
                    ShipThrusterModel thrusterModel = ship.GetComponent<ShipThrusterModel>();
                    thrusterModel._maxTranslationalThrust *= 2;
                    thrusterModel._maxRotationalThrust *= 2;
                }
                GameObject upsilonAndromedaeFocalPoint = NewHorizonsAPI.GetPlanet("Upsilon Andromedae");
                if (upsilonAndromedaeFocalPoint != null)
                {
                    upsilonAndromedaeFocalPoint.transform.DestroyAllChildrenImmediate();
                }
                GameObject saffar = NewHorizonsAPI.GetPlanet("Saffar");
                GameObject tion = NewHorizonsAPI.GetPlanet("Tion");
                if (saffar != null && tion != null)
                {
                    saffar.GetComponent<AstroObject>()._moon = tion.GetComponent<AstroObject>();
                }
                GameObject samh = NewHorizonsAPI.GetPlanet("Samh");
                GameObject tuitan = NewHorizonsAPI.GetPlanet("Tuitan");
                if (samh != null && tuitan != null)
                {
                    samh.GetComponent<AstroObject>()._moon = tuitan.GetComponent<AstroObject>();
                }
                GameObject majriti = NewHorizonsAPI.GetPlanet("Majriti");
                GameObject britomartis = NewHorizonsAPI.GetPlanet("Britomartis");
                if (majriti != null && britomartis != null)
                {
                    majriti.GetComponent<AstroObject>()._moon = britomartis.GetComponent<AstroObject>();
                }
                GameObject zarqali = NewHorizonsAPI.GetPlanet("Zarqali");
                GameObject aura = NewHorizonsAPI.GetPlanet("Aura");
                if (zarqali != null && aura != null)
                {
                    zarqali.GetComponent<AstroObject>()._moon = aura.GetComponent<AstroObject>();
                }
            }
        }

        private void Start()
        {
            NewHorizonsAPI = ModHelper.Interaction.GetModApi<INewHorizons>("xen.NewHorizons");
            NewHorizonsAPI.LoadConfigs(this);
            NewHorizonsAPI.GetStarSystemLoadedEvent().AddListener(OnStarSystemLoaded);
        }
    }
}
