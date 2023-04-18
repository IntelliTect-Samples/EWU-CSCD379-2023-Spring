# Notes
Problem: The letters are case sensitive A != a
Solution: Force the case to only type in all caps
        or change the user input to the same case as secret word


Help:
- How to change the icon in the tab (favicon.ico)?


# Random code snippets:

### Setting menu for app.vue
          <template>
            <v-row justify="center">
              <v-dialog v-model="dialog" persistent width="auto">
                <template v-slot:activator="{ props }">
                  <v-btn v-bind="props">
                    <v-icon size='25px' icon="mdi:mdi-cog" />
                  </v-btn>
                </template>
                <v-card>
                  <v-card-title class="text-h5">Settings</v-card-title>
                  <v-card-text>
                    whatever we want the settings to be later
                  </v-card-text>
                  <v-card-actions>
                    <v-spacer/>
                    <v-btn color="primary" variant="text" @click="dialog = false">Cancel</v-btn>
                    <v-btn color="primary" variant="text" @click="dialog = false">Save</v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
            </v-row>
          </template>