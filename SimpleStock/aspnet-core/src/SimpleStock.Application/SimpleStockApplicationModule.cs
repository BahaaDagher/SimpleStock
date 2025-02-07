using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace SimpleStock;

[DependsOn(
    typeof(SimpleStockDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(SimpleStockApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpCachingStackExchangeRedisModule)
    )]
public class SimpleStockApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SimpleStockApplicationModule>();
        });
        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "SimpleStosk_";
            
        });
    }
}
