using Application.Presenters;
using Application.ViewModels;
using Domain.Requests;
using Domain.Services.Interfaces;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Application.Apis
{
    [ApiController]
    [Route("/api/beers")]
    public class BeerController : Controller
    {
        private readonly IBeerCatalog _catalog;

        public BeerController(IBeerCatalog catalog)
        {
            _catalog = catalog;
        }
        
        [HttpGet("")]
        public ActionResult<ApiGetAllBeersViewModel> GetAllBeers([FromQuery] GetAllBeersRequest request)
        {
            var useCase = new GetAllBeersUseCase(_catalog);

            var presenter = new ApiGetAllBeersPresenters();

            useCase.Execute(request, presenter);

            var vm = presenter.ViewModel;

            return vm.HttpCode == 204 ? NoContent() : (ActionResult) Ok(vm);
        }

        [HttpGet("{id}")]
        public ActionResult<ApiGetOneBeerViewModel> GetOneBeer([FromRoute] GetOneBeerRequest request)
        {
            var useCase = new GetOneBeerUseCase(_catalog);

            var presenter = new ApiGetOneBeerPresenter();

            useCase.Execute(request, presenter);

            var vm = presenter.ViewModel;

            return vm.HttpCode == 404 ? NotFound() : (ActionResult) Ok(vm);
        }

        [HttpPost("")]
        public ActionResult<ApiAddBeerViewModel> AddBeer([FromBody] AddBeerRequest request)
        {
            var useCase = new AddBeerUseCase(_catalog);

            var presenter = new ApiAddBeerPresenter();

            useCase.Execute(request, presenter);

            var vm = presenter.ViewModel;

            return vm.HttpCode == 201
                ? Created($"/api/beers/{vm.Data.GetType().GetProperty("Id")?.GetValue(vm.Data)}", vm)
                : (ActionResult) BadRequest(vm);
        }

        [HttpPut("{id}")]
        public ActionResult<ApiUpdateBeerViewModel> UpdateBeer([FromBody] [FromRoute] UpdateBeerRequest request)
        {
            var useCase = new UpdateBeerUseCase(_catalog);

            var presenter = new ApiUpdateBeerPresenter();

            useCase.Execute(request, presenter);

            var vm = presenter.ViewModel;

            return vm.HttpCode == 201 ? Ok(vm) : (ActionResult) BadRequest(vm);
        }

        [HttpDelete("{id}")]
        public ActionResult<ApiDeleteBeerViewModel> DeleteBeer([FromRoute] DeleteBeerRequest request)
        {
            var useCase = new DeleteBeerUseCase(_catalog);

            var presenter = new ApiDeleteBeerPresenter();

            useCase.Execute(request, presenter);

            return NoContent();
        }

        [HttpPost("checkavailability")]
        public ActionResult<ApiCheckBeersAvailabilityViewModel> CheckBeersAvailability(
            [FromBody] CheckBeersAvailabilityRequest request)
        {
            var useCase = new CheckBeersAvailabilityUseCase(_catalog);

            var presenter = new ApiCheckBeersAvailabilityPresenter();

            useCase.Execute(request, presenter);

            var vm = presenter.ViewModel;

            return vm.HttpCode == 200 ? Ok(vm) : (ActionResult) BadRequest(vm);
        }

        [HttpPost("buy")]
        public ActionResult<ApiBuyBeersViewModel> BuyBeers([FromBody] BuyBeersRequest request)
        {
            var useCase = new BuyBeersUseCase(_catalog);

            var presenter = new ApiBuyBeersPresenter();

            useCase.Execute(request, presenter);

            var vm = presenter.ViewModel;

            return vm.HttpCode == 200 ? Ok(vm) : (ActionResult) BadRequest(vm);
        }
    }
}