# ddc24-devsession

Material for the DevSession about Micro Frontends at the DDC 24 in Cologne.

## API Calls

Retrieve the movies:

- Most popular movies:
  `https://api.themoviedb.org/3/movie/popular?api_key={key}&language=en-US`

- Movies now in theater:
  `https://api.themoviedb.org/3/movie/now_playing?api_key={key}&language=en-US`

- Details about a movie:
  `https://api.themoviedb.org/3/movie/{id}?api_key={key}&language=en-US`

- Most popular TV shows:
  `https://api.themoviedb.org/3/tv/popular?api_key={key}&language=en-US`

- Details about a TV show:
  `https://api.themoviedb.org/3/tv/{id}?api_key={key}&language=en-US`

- Search:
  `https://api.themoviedb.org/3/search/{type}?api_key={key}&language=en-US&query=${q}&page=1`

Use the following API key (only for personal / localhost development):

```plain
3fd2be6f0c70a2a598f084ddfb75487c
```

Otherwise you can register your own key at https://www.themoviedb.org/settings/api and use it instead.

## Behavior

### Movies Content

Retrieve the now playing movies. For each item `movie`:

```html
<div class="swiper-slide">
  <a href="/movies/{movie.id}">
    <img src="https://image.tmdb.org/t/p/w500{movie.poster_path}" alt="{movie.title}" />
  </a>
  <h4 class="swiper-rating">
    <i class="fas fa-star text-secondary"></i> {movie.vote_average} / 10
  </h4>
</div>
```

Append these to the `.swiper-wrapper` element.

Retrieve the popular movies. For each item `movie`:

```html
<div class="card">
  <a href="/movies/{movie.id}">
    <img src="https://image.tmdb.org/t/p/w500{movie.poster_path}" class="card-img-top" alt="{movie.title}" />`
  </a>
  <div class="card-body">
    <h5 class="card-title">{movie.title}</h5>
    <p class="card-text">
      <small class="text-muted">Release: {movie.release_date}</small>
    </p>
  </div>
</div>
```

**Note**: In case there is no `movie.poster_path` you can just reference the `/images/no-image.png` fallback image.

Append these to the `#popular-movies` element.

Initialize slider (via JS):

```js
new Swiper('.swiper', {
  slidesPerView: 1,
  spaceBetween: 30,
  freeMode: true,
  loop: true,
  autoplay: {
    delay: 4000,
    disableOnInteraction: false,
  },
  breakpoints: {
    500: {
      slidesPerView: 2,
    },
    700: {
      slidesPerView: 3,
    },
    1200: {
      slidesPerView: 4,
    },
  },
});
```

### TV Shows Content

Retrieve the popular TV shows. For each item `show`:

```html
<div class="card">
  <a href="/tv-shows/{show.id}">
    <img src="https://image.tmdb.org/t/p/w500{show.poster_path}" class="card-img-top" alt="{show.name}" />`
  </a>
  <div class="card-body">
    <h5 class="card-title">{show.name}</h5>
    <p class="card-text">
      <small class="text-muted">Air Date: {show.first_air_date}</small>
    </p>
  </div>
</div>
```

**Note**: In case there is no `show.poster_path` you can just reference the `/images/no-image.png` fallback image.

Append these to the `#popular-shows` element.

### Movies and TV Show Details

Retrieve details of movie or TV show from the API (referred to as `item`).

Insert backdrop image for `item.backdrop_path`:

```html
<div style="background-image: url(https://image.tmdb.org/t/p/original/{backgroundPath})" class="backdrop">
</div>
```

Append to the element `#details`.

Also generate the content for the details. Here we distinguish between movie and TV show.

#### Movie Details

```html
<div>
  <div class="details-top">
    <div>
      <img src="https://image.tmdb.org/t/p/w500{item.poster_path}"
           class="card-img-top"
           alt="{item.title}" />
    </div>
    <div>
      <h2>{item.title}</h2>
      <p>
        <i class="fas fa-star text-primary"></i>
        {item.vote_average.toFixed(1)} / 10
      </p>
      <p class="text-muted">Release Date: {item.release_date}</p>
      <p>
        {item.overview}
      </p>
      <h5>Genres</h5>
      <ul class="list-group">
        {item.genres.map((genre) => <li>{genre.name}</li>)}
      </ul>
      <a href="{item.homepage}" target="_blank" class="btn">Visit Movie Homepage</a>
    </div>
  </div>
  <div class="details-bottom">
    <h2>Movie Info</h2>
    <ul>
      <li><span class="text-secondary">Budget:</span> $ {item.budget}</li>
      <li><span class="text-secondary">Revenue:</span> $ {item.revenue}</li>
      <li><span class="text-secondary">Runtime:</span> {item.runtime} minutes</li>
      <li><span class="text-secondary">Status:</span> {item.status}</li>
    </ul>
    <h4>Production Companies</h4>
    <div class="list-group">
      {item.production_companies.map((company) => <span>${company.name}</span>)}
    </div>
  </div>
</div>
```

#### TV Show Details

```html
<div>
  <div class="details-top">
    <div>
      <img src="https://image.tmdb.org/t/p/w500{item.poster_path}"
           class="card-img-top"
           alt="{item.name}" />
    </div>
    <div>
      <h2>{item.name}</h2>
      <p>
        <i class="fas fa-star text-primary"></i>
        {item.vote_average.toFixed(1)} / 10
      </p>
      <p class="text-muted">Last Air Date: {item.last_air_date}</p>
      <p>
        {item.overview}
      </p>
      <h5>Genres</h5>
      <ul class="list-group">
        {item.genres.map((genre) => <li>{genre.name}</li>)}
      </ul>
      <a href="{item.homepage}" target="_blank" class="btn">Visit Show Homepage</a>
    </div>
  </div>
  <div class="details-bottom">
    <h2>Show Info</h2>
    <ul>
      <li><span class="text-secondary">Number of Episodes:</span> {item.number_of_episodes}</li>
      <li><span class="text-secondary">Last Episode To Air:</span> {item.last_episode_to_air.name}</li>
      <li><span class="text-secondary">Status:</span> {item.status}</li>
    </ul>
    <h4>Production Companies</h4>
    <div class="list-group">
      {item.production_companies.map((company) => <span>${company.name}</span>)}
    </div>
  </div>
</div>
```

### Search Content

Call the search API using the `query` and `type` parameters. From the response we get `results`, `total_pages`, `page`, `total_results`.

The URL is supposed to be `/search/{type}?q={query}`.

For an empty `query` or an empty result set display a fallback ("nothing found").

Foreach `result` in `results`:

```html
<div class="card">
  <a href="{type ? movies : tv-shows}/{result.id}">
    <img src="https://image.tmdb.org/t/p/w500{result.poster_path}"
         class="card-img-top"
         alt="{type ? result.title : result.name}" />
  </a>
  <div class="card-body">
    <h5 class="card-title">{type ? result.title : result.name}</h5>
    <p class="card-text">
      <small class="text-muted">Release: {type ? result.release_date : result.first_air_date}</small>
    </p>
  </div>
</div>
```

Append those to the `#search-result` element.

**Note**: The `type ?` notation refers to if "type is movies then select the first one, otherwise the other one".

Set the `#search-results-heading` element to contain:

```html
<h2>{results.length} of {total_results} Results for {query}</h2>
```

Append to the `#pagination` element:

```html
<div class="pagination">
  <button class="btn btn-primary" id="prev">Prev</button>
  <button class="btn btn-primary" id="next">Next</button>
  <div class="page-counter">Page {page} of {total_pages}</div>
</div>
```

Clicking `prev` or `next` should re-trigger the search with a different `page` value. Disable `prev` when `page` is 1 (initial value). Disable `next` when `page` is `total_pages`.

## License

The repository is distributed under the [MIT License](./LICENSE).
