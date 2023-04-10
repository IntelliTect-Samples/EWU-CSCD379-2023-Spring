<template>
    <div class="game">
        <v-card>
          <v-card-title>
              <h1>Word War 1</h1>
          </v-card-title>

          <v-card-subtitle>
              <p>Title work in progress</p>
          </v-card-subtitle>

          <v-card-text>
              <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Esse vitae est quae magni sequi harum, expedita laborum ullam alias perspiciatis. Cupiditate at error laborum nostrum, magni praesentium maxime possimus voluptatum inventore molestias unde sed facere sunt ea dolorem suscipit eum mollitia ad id repellendus dolore voluptates. Reprehenderit sit, ad id quis veritatis odit nostrum minima a officiis ut iusto nobis quod quae beatae cumque consequuntur. Itaque, voluptas atque pariatur id laboriosam eligendi vel repellat maxime delectus incidunt iure mollitia deleniti officia quia nobis officiis doloribus neque natus aperiam nostrum? Voluptate aut quasi alias accusantium dolore saepe ipsam veritatis, repellendus optio quisquam. Necessitatibus iure numquam rem at dolor molestiae laborum veritatis quasi deleniti voluptatem soluta ipsa iusto accusamus, magnam laboriosam reprehenderit tenetur fugit minus explicabo maxime exercitationem nobis est. Eos temporibus asperiores provident consequuntur ullam doloremque! Quia esse non dolor quo laudantium accusamus explicabo libero dolores dolorum, quod consequatur at eveniet consectetur ipsa eaque, veniam id? Nostrum fugit consequatur, ea nihil excepturi aliquam beatae dolores atque tempora illum provident earum deleniti magnam aliquid dolore alias veniam optio blanditiis delectus, sunt accusantium rerum vitae. Corrupti autem libero facere voluptatibus labore alias laborum, repellendus blanditiis veniam officia expedita exercitationem, nisi quas saepe nam?</p>
          </v-card-text>
          
          <v-card-actions>
            <RouterLink to="/">
              <v-btn variant="outlined">
                Return Home
              </v-btn>
            </RouterLink>
          </v-card-actions>

        </v-card>
    </div>
  </template>
  
  <style>
  .icon {
    margin: 8px;
  }
  @media (min-width: 1024px) {
    .game {
      min-height: 100vh;
      display: flex;
      align-items: center;
      justify-content: center;
    }
  }
  </style>