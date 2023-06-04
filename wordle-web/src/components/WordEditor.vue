<template>
  <div class="text-center">
    <v-btn color="primary" @click="openDialog">Edit Dictionary</v-btn>

    <v-dialog v-model="dialog" width="auto">
      <v-card>
        <v-card-text>Word Editor</v-card-text>
        
      </v-card>
      <v-sheet width="300" class="mx-auto">
        <v-form ref="form">
          <v-text-field
            v-model="input"
            :counter="10"
            :rules="wordRules"
            label="Name"
            required
          ></v-text-field>
          <v-row class="d-flex flex-wrap bg-surface-variant">
          <p>Is Common: </p>
          <input type="checkbox"  v-model="toggle" true-value="yes" false-value="no">
          </v-row>

          <div class="d-flex flex-column">
            <v-btn color="success" class="mt-4" block @click="addWordAndRefresh" >Add</v-btn>

            <v-btn color="error" class="mt-4" block @click="flipIsCommon">
              Flip Is Common Value
            </v-btn>

            <v-btn color="warning" class="mt-4" block @click="removeAndRefresh">
              Remove Word
            </v-btn>
          </div>
        </v-form>
        <v-card-actions>
          <v-btn color="primary" block @click="closeDialog">Close Dialog</v-btn>
        </v-card-actions>
      </v-sheet>
      
    </v-dialog>
  </div>
</template>

<script lang="ts">
import Axios from 'axios';

export default {
  emits: ['refresh'], // Specify the emitted event name

  data() {
    return {
      dialog: false,
      input: '',
      toggle: 'no',
      valid: true,
      wordRules: [
        (v: string) => !!v || 'Word is required',
        (v: string) => !/[^\p{L}]/u.test(v) || 'Word must only contain letters',
        (v: string) => (v && v.length === 5) || 'Word must be 5 characters',
      ],
    };
  },

  methods: {
    openDialog() {
      this.dialog = true;
    },

    closeDialog() {
      this.dialog = false;
    },

    removeWord() {
      console.log('Removing: ' + this.input);
      return Axios.post(`/Word/DropWord?word=${this.input}`, { word: this.input })
        .then((response) => {
          console.log('Response:', response.data);
          console.log('Did Word Successfully Get Removed: ' + response.data);
          return response.data;
        })
        .catch((error) => {
          console.log('Axios Error:', error);
          return false;
        });
    },

    removeAndRefresh() {
      this.removeWord().then((isRemoved) => {
        if (isRemoved || (typeof isRemoved === 'string' && isRemoved.trim() === 'true')) {
          console.log('Refresh Dictionary - Word Editor');
          this.$emit('refresh'); // Emit the event to trigger the parent action
          this.closeDialog(); // Close the dialog after emitting the event
        } else {
          console.log('Type of IsRemoved: ' + typeof isRemoved);
          console.log('What is removed? ' + isRemoved);
        }
      }).catch((error) => {
        console.log('Error:', error);
      });
    },

    addWordAndRefresh() {
      Axios.get(`/Word/AddWord?word=${this.input}`).then((isAdded) => {
        
        if (isAdded) {
          console.log('Refresh Dictionary - Word Editor');
          this.$emit('refresh'); // Emit the event to trigger the parent action
          this.closeDialog(); // Close the dialog after emitting the event
        } else {
          console.log('Type of IsRemoved: ' + typeof isAdded);
          console.log('What is removed? ' + isAdded);
        }
      }).catch((error) => {
        console.log('Error:', error);
      });

    },

    flipIsCommon() {
      Axios.get(`/Word/FlipIsCommon?word=${this.input}`).then((response) => {
        console.log(response.data);
      });
    },
  },
};
</script>